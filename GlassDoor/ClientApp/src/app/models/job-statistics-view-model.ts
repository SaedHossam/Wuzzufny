export class JobStatisticsViewModel {

  constructor(
    public TotalApplications?: number,
    public ViewedApplications?: number,
    public InConsiderationApplications?: number,
    public RejectedApplications?: number,
    public HiredApplications?: number,
    public TotalClicks?: number
  ) { }
}
