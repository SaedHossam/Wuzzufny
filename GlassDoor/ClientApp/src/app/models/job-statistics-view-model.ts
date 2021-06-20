export class JobStatisticsViewModel {

  constructor(
    public TotalApplications?: number,
    public ViewedApplications?: number,
    public InConsidrationApplications?: number,
    public RejectedApplications?: number,
    public HiredApplications?: number,
    public TotalClicks?: number
  ) { }
}
